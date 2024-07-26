export default function Student() {
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
