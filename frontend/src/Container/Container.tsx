import React, { Component, ChangeEvent } from "react";
import axios, { AxiosResponse } from "axios";
import { urlContacts } from "../endpoints";
import IContactData from "../Types/contact.type";

type Props = {};
type State = {
	contacts: Array<IContactData>;
	total: number;
};

class Container extends React.Component<Props, State> {
	state: State = {
		contacts: [],
		total: 0,
	};

	componentDidMount() {
		return axios.get(urlContacts).then((response: AxiosResponse) => {
			this.setState({ contacts: response.data, total: response.data.length });
			console.log(this.state);
			console.log(response.data);
		});
	}

	render() {
		return <div></div>;
	}
}
export default Container;
