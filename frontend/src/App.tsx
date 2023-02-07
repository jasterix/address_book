import React, { useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios, { AxiosResponse } from "axios";

function App() {
	useEffect(() => {
		axios
			.get("http://localhost:5240/api/Contacts")
			.then((response: AxiosResponse<any>) => {
				console.log(response.data);
			});
	}, []);

	return (
		<div className="App">
			<header>Making sure api is connected</header>
		</div>
	);
}

export default App;
