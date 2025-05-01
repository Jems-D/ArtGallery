import { Outlet } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import { UserProvider } from "./Context/useAuth";

function App() {
  return (
    <>
      <UserProvider>
        <Navbar />
        <Outlet />
      </UserProvider>
    </>
  );
}

export default App;
