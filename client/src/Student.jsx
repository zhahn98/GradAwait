import { useEffect } from "react"

export default function Student() {
  const getData = async () => {
    const response = await fetch("https://localhost:5001/api/project")
    const projects = await response.json()
    console.log("🚀 ~ getData ~ projects:", projects)
  }
  useEffect(() => {
    console.log("mounted")
    getData()
  }, [])
  return (
    <div className="py-20">
      <Header>Hello</Header>
      <Header>Again</Header>
    </div>
  )
}

function Header({ children }) {
  return <p className="text-4xl">{children}</p>
}
