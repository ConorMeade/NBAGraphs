import React, { useState, useEffect, PureComponent } from "react";
import StatTypes from "../Interfaces/StatTypes";
import { BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

//type StatMeasurements = 

interface PlayerStats {
    _id: string,
    firstName: string,
    lastName: string,
    stat: number,
    primary_color: string
}

function Graph(props: StatTypes) {
    const [points, setPoints] = useState<PlayerStats[]>([]);
    const [rebounds, setRebounds] = useState<PlayerStats[]>([]);
    const [assists, setAssists] = useState<PlayerStats[]>([]);
    const [displayData, setDisplayData] = useState(points);
    // const [stats, setStats] = useState([]);
    let statEndpoints = new Map<string, string>();
    statEndpoints.set("ppg", "LeadingScorers")
    statEndpoints.set("apg", "LeadingAssists")
    statEndpoints.set("rpg", "LeadingRebounds")


   // const barData = Arr
    let endpointEnding = statEndpoints[props.stat]

    useEffect(() => {
        const loadPointsData = async () => {
            await fetch(`http://localhost:44484/api/Player/LeadingScorers`)
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
          await fetch(`http://localhost:44484/api/Player/LeadingAssists`)
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
          await fetch(`http://localhost:44484/api/Player/LeadingRebounds`)
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
      setDisplayData(points)
    }

    const handleGraphChangeAsts = () => {
      setDisplayData(assists)
    }
    const handleGraphChangeRebs = () => {
      setDisplayData(rebounds)
    }

    const barItems = displayData.map((obj) => {
      return (<Bar dataKey={obj.stat}
                   fill={obj.primary_color}/>
        )
    })
    return (


      <div>
        <ResponsiveContainer width="100%" height="100%">
          <BarChart
            width={500}
            height={300}
            data={displayData}
            margin={{
              top: 5,
              right: 30,
              left: 20,
              bottom: 5,
            }}
          >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="name" />
            <YAxis dataKey="points"/>
            <Tooltip />
            <Legend />
            {barItems}
          </BarChart>
        </ResponsiveContainer>

        <button onClick={handleGraphChangePoints}>Point Leaders</button>
        <button onClick={handleGraphChangeAsts}>Assist Leaders</button>
        <button onClick={handleGraphChangeRebs}>Rebound Leaders</button>
      </div>
    );
}

export default Graph;