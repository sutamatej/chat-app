import React from 'react';
import { HubConnectionBuilder } from "@microsoft/signalr";

export function Chat() {
    const [connection, setConnection] = React.useState();
    const [message, setMessage] = React.useState();
    const [messages, setMessages] = React.useState([]);

    React.useEffect(() => {
        const connection = new HubConnectionBuilder().withUrl("/chathub").build();

        connection.on("ReceiveMessage", (user, message) => {
            setMessages(prevMessages => [...prevMessages, message]);
        });

        connection.start().then(() => {
            setConnection(connection);
        });
    }, []);

    const sendMessage = React.useCallback(() => {
        if (connection) {
            connection.invoke("SendMessage", "me", message);
            setMessage("");
        }
    }, [message]);

    return (
        <>
            <ol>
                {messages.map(m => {
                    return (
                        <li
                            key={m.id}
                        >
                            {m}
                        </li>
                    );
                })}
            </ol>

            <input
                type="text"
                onChange={(e) => setMessage(e.target.value)}
                value={message}
            />
            <button type="button" onClick={sendMessage}>Send</button>
        </>
    );
}