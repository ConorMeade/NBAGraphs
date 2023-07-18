import React, { useState, useEffect } from "react";
//import { BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

import {Chart as ChartJS, BarElement, CategoryScale, LinearScale, Tooltip, Legend } from 'chart.js';
import { Bar } from 'react-chartjs-2';

// interface PlayerStats {
//     _id: string,
//     firstName: string,
//     lastName: string,
//     stat: number,
//     primary_color: string
// }

ChartJS.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend)


function Graph() {
  const [points, setPoints] = useState([]);
  const [rebounds, setRebounds] = useState([]);
  const [assists, setAssists] = useState([]);
  const [displayType, setDisplayType] = useState(1)
  const options = {}

  useEffect(() => {
      const loadPointsData = async () => {
          await fetch(`api/Player/LeadingScorers`)
          .then((response) => {
              if (!response.ok) {
                throw new Error(
                  `This is an HTTP error: The status is ${response.status}`
                );
              }
              return response.json();
            })
            .then((statData) => setPoints(statData))
            .catch((err) => {
              console.log(err.message);
          });
      }

      const loadAssistsData = async () => {
        await fetch(`api/Player/LeadingAssists`)
        .then((response) => {
            if (!response.ok) {
              throw new Error(
                `This is an HTTP error: The status is ${response.status}`
              );
            }
            return response.json();
          })
          .then((statData) => setAssists(statData))
          .catch((err) => {
            console.log(err.message);
        });
      }

      const loadReboundsData = async () => {
        await fetch(`api/Player/LeadingRebounds`)
        .then((response) => {
            if (!response.ok) {
              throw new Error(
                `This is an HTTP error: The status is ${response.status}`
              );
            }
            return response.json();
          })
          .then((statData) => setRebounds(statData))
          .catch((err) => {
            console.log(err.message);
        });
      }
      loadPointsData();
      loadReboundsData();
      loadAssistsData();
  }, []);

  const handleGraphChangePoints = () => {
    setLbls(points.map((obj) => obj.lastName))
    setDisplayType(1)
  }

  const handleGraphChangeAsts = () => {
    setLbls(assists.map((obj) => obj.lastName))
    setDisplayType(2)
  }
  const handleGraphChangeRebs = () => {
    setLbls(rebounds.map((obj) => obj.lastName))
    setDisplayType(3)
  }


  const labels = points.map((obj) => obj.lastName)

  const [lbls, setLbls] = useState(labels)
  const pointsDataPts = points.map(obj => {
    return { label: obj.lastName, data: [obj.ppg], backgroundColor: "#" + obj.primary_color }
  });

  const assistsDataPoints = assists.map(obj => {
    return { label: obj.lastName, data: [obj.apg], backgroundColor: "#" + obj.primary_color }
  });

  const reboundsDataPts = rebounds.map(obj => {
    return { label: obj.lastName, data: [obj.rpg], backgroundColor: "#" + obj.primary_color }
  });

  const pointsGraphData = {
    labels: points.map((obj) => obj.lastName),
    datasets: pointsDataPts,
    borderColor: 'black',
    borderWidth: 1,
  }

  const assistsGraphData = {
    labels: assists.map((obj) => obj.lastName),
    datasets: assistsDataPoints,
    borderColor: 'black',
    borderWidth: 1,
  }

  const reboundsGraphData = {
    labels: rebounds.map((obj) => obj.lastName),
    datasets: reboundsDataPts,
    borderColor: 'black',
    borderWidth: 1,
  }

  console.log(pointsGraphData)
  console.log(assistsGraphData)
  console.log(reboundsGraphData)

  if(displayType === 1) {
    return (
      <>
      
        <Bar
          data={pointsGraphData}
          options={options}
        >
        </Bar>
        <div style={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}>
          <button onClick={handleGraphChangePoints}>Point Leaders</button>
          <button onClick={handleGraphChangeAsts}>Assist Leaders</button>
          <button onClick={handleGraphChangeRebs}>Rebound Leaders</button>
        </div>
      </>
    );
  }
  if(displayType === 2) {
    return (
      <>
      
        <Bar
          data={assistsGraphData}
          options={options}
        >
        </Bar>
        <div style={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}>
          <button onClick={handleGraphChangePoints}>Point Leaders</button>
          <button onClick={handleGraphChangeAsts}>Assist Leaders</button>
          <button onClick={handleGraphChangeRebs}>Rebound Leaders</button>
        </div>
      </>
    );
  }
  if(displayType === 3) {
    return (
      <>
      
        <Bar
          data={reboundsGraphData}
          options={options}
        >
        </Bar>
        <div style={{
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}>
          <button onClick={handleGraphChangePoints}>Point Leaders</button>
          <button onClick={handleGraphChangeAsts}>Assist Leaders</button>
          <button onClick={handleGraphChangeRebs}>Rebound Leaders</button>
        </div>
      </>
    );
  }
}

export default Graph;