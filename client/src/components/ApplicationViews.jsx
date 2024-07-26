import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute"
import Login from "./auth/Login"
import Register from "./auth/Register"
import Student from "../Student"

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  console.log(loggedInUser)
  return (
    <Routes>
      <Route path="/">
        {/* <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}></AuthorizedRoute>
          }
        /> */}

        {/* THIS IS WHERE WE CAN PUT EACH OF OUR VIEWS */}
        <Route path="student" element={<Student />} />

        {/* THIS IS WHERE WE CAN PUT EACH OF OUR VIEWS */}
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  )
}
