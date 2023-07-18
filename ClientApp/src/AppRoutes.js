import Graph from "./components/Graph";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/fetch-data',
    element: <Graph />
  }
];

export default AppRoutes;
