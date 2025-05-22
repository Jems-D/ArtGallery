import { Outlet } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import { UserProvider } from "./Context/useAuth";
import { ToastContainer } from "react-toastify";

function App() {
  return (
    <>
      <UserProvider>
        <Navbar />
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>
  );
}

export default App;
