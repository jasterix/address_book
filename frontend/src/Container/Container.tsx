import React, { useEffect, useState } from "react";
import axios, { AxiosResponse } from "axios";
import { urlContacts } from "../endpoints";

type Props = {};
type State = {};
const Container: React.FC = () => {
	// state = {
	// 	total: 0,
	// 	contacts: [],
	// };
	const [contacts, setContacts] = React.useState([]);
	const [total, setTotal] = React.useState(0);

	const getContactsAsync = async () => {
		try {
			const resp = await axios.get(urlContacts);

			console.log(resp.data);
		} catch (error) {
			// Handle Error Here
			console.error(`Error: ${error}`);
		}
		console.log(contacts);
	};

	return <div></div>;
};
export default Container;
