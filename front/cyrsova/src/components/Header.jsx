import "./Header.css";
import { Link } from "react-router-dom";
import { HEADER_ROUTES } from "../constants";
import { useUser } from "../context/UserContext";
import exitImg from "../img/exit.png";
import { toast } from "react-toastify";
function Header() {
  const { user, crystals,loadingCrystals  } = useUser();
  const storedUser = localStorage.getItem("user");
  const userName = JSON.parse(storedUser)?.user?.name
  const userRole = JSON.parse(storedUser)?.user?.role;
const handleLogout = () => {
        toast.success("Logged out successfully");

  localStorage.removeItem("user");


    
  };
  return (
    <header className="header">
      <div className="header-main">
        <Link to={HEADER_ROUTES.HOME} className="logo">
          TestApp
        </Link>

        <nav className="header-nav">
          <Link to={HEADER_ROUTES.TESTS} className="nav-tests-btn!">
            Tests
          </Link>
                    <Link to={HEADER_ROUTES.MyTests} className="nav-tests-btn!">
            MyTests
          </Link>
          {userRole === 1 && (
  <Link to={HEADER_ROUTES.AdminPanel} className="nav-tests-btn!">
    Admin Panel
  </Link>
)}
        </nav>
      </div>


 
      
      <div className="auth-buttons">
        
      <Link to={HEADER_ROUTES.Reneme}>
      <span className="username">{userName}</span>
      </Link>
        


<span>
  💎 {loadingCrystals || crystals === null ? "..." : crystals}
  
</span>

<Link to="/login">
<img  onClick={handleLogout} className="img-exit" src={exitImg} alt="" />
</Link>


      </div>
      
    </header>
  );
}

export default Header;