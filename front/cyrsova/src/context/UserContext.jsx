import { createContext, useContext, useState, useEffect } from "react";

const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [crystals, setCrystals] = useState(0);
  const [loadingCrystals, setLoadingCrystals] = useState(true);

 useEffect(() => {
  const storedUser = localStorage.getItem("user");

  if (!storedUser || storedUser === "null") return;

  const parsed = JSON.parse(storedUser);
  setUser(parsed);

  const load = async () => {
    setLoadingCrystals(true);

    try {
      const res = await fetch(
        `https://localhost:7166/api/crystals?userId=${parsed.user.id}`
      );
      const data = await res.json();

      if (data.isSuccess) {
        setCrystals(data.payload);
      }
    } catch (e) {
      console.error(e);
    } finally {
      setLoadingCrystals(false);
    }
  };

  load();
}, []);

  const fetchCrystals = async (userId) => {
    setLoadingCrystals(true);

    try {
      const res = await fetch(
        `https://localhost:7166/api/crystals?userId=${userId}`
      );
      const data = await res.json();

      if (data.isSuccess) {
        setCrystals(data.payload ?? 0);
      }
    } catch (e) {
      console.error(e);
    } finally {
      setLoadingCrystals(false);
    }
  };

  const addCrystals = async (amount) => {
    if (!user) return;

    try {
      const res = await fetch(
        `https://localhost:7166/api/crystals/add?userId=${user.user.id}&amount=${amount}`,
        {
          method: "POST",
          headers: { accept: "*/*" },
        }
      );

      const data = await res.json();

      if (data.isSuccess) {

        await fetchCrystals(user.user.id);
      }
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <UserContext.Provider
      value={{
        user,
        setUser,
        crystals,
        loadingCrystals,
        addCrystals,
        fetchCrystals,
      }}
    >
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => useContext(UserContext);