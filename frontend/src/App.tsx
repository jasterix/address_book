import React, { useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios, { AxiosResponse } from "axios";
import { urlContacts } from "./endpoints";

function App() {
	useEffect(() => {
		axios.get(urlContacts).then((response: AxiosResponse<any>) => {
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
