import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';

export class Airports extends Component {
  static displayName = Airports.name;

  state = {
      airports: [],
      loading: true,
      selectedAirport: null
  };

  componentDidMount() {
      axios.get('/api/airports/all').then(response => {
          let allAirports = response.data;
          this.setState({ airports: allAirports, loading: false });
      });
  }

  addAirport() {
    let addEditInputValue = ReactDOM.findDOMNode(this.refs.airportAddEdit).value;
    axios.post(`/api/airports/add`, { cityName: addEditInputValue })
    .then(() => {
        axios.get('/api/airports/all').then(response => {
            let allAirports = response.data;
            this.setState({ airports: allAirports });
        });
    }).catch(() => {
        alert("Add unsuccessful");
    });;
  }

  editAirport(id) {
    let addEditInputValue = ReactDOM.findDOMNode(this.refs.airportAddEdit).value;
    axios.post(`/api/airports/edit`, { id: id,  cityName: addEditInputValue })
    .then(() => {
        axios.get('/api/airports/all').then(response => {
            let allAirports = response.data;
            this.setState({ airports: allAirports });
        });
    }).catch(() => {
        alert("Edit unsuccessful");
    });;
  }

  deleteAirport(id) {
    axios.delete(`api/airports/delete/${id}`).then(() => {
        axios.get('/api/airports/all').then(response => {
            let allAirports = response.data;
            this.setState({ airports: allAirports });
        });
    }).catch(() => {
        alert("Delete unsuccessful");
    });
  }

  getById() {
    let addEditInputValue = ReactDOM.findDOMNode(this.refs.airportAddEdit).value;
    axios.get(`/api/airports/get-by-id`, { params: {
        id: addEditInputValue
      } 
    })
    .then(response => {
        this.setState({ selectedAirport: response.data });
    }).catch(() => {
        alert("Airport not found");
    });;
  }

  render () {
    return (
      <div>
        <h1>Airports</h1>
        <p>The component automatically fetches airport data. You can then add new airports, edit or delete existing ones.</p>
        {this.state.loading ? (
            <p>Loading...</p>
        ) : (
            this.state.airports.map(airport => 
                <div>
                    <div key={airport.id}>{airport.cityName}</div>
                    <button onClick={() => this.editAirport(airport.id)}>EDIT</button>
                    <button onClick={() => this.deleteAirport(airport.id)}>DELETE</button>
                </div>
            )
            )}
        <input type="text" ref="airportAddEdit" placeholder="Input for add or edit" />
        <button onClick={() => this.addAirport()}>ADD</button>
        <button onClick={() => this.getById()}>GET BY ID</button>
        { this.state.selectedAirport !== null ? (<div>Selected airport: {this.state.selectedAirport.cityName}</div>) : (<div>No selected airport.</div>) }
      </div>
    );
  }
}