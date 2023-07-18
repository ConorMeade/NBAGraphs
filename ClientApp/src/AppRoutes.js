import Graph from "./components/Graph.js";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/Graph',
    element: <Graph />
  }
];

export default AppRoutes;
