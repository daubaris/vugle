import React from 'react';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';

import styles from './chat.scss';

class Chat extends React.Component {
    render() {
        return (
            <div className={ styles['chat'] }>
                <div className={ styles['char-area'] }>
					<Messages type='user' message={ 'one two' }/>
					<Messages message={ 'one two' }/>
                </div>
                <SuggestionBar />
            </div>
        );
    }
}

export default Chat;
