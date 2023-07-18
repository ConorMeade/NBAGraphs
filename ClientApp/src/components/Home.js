import React, { Component } from 'react';
import Graph from './Graph.js';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <Graph/>
      </div>
    );
  }
}
