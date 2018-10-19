import React from 'react';

import { SuggestionBar } from './suggestion-bar';

import styles from './chat.scss';

class Chat extends React.Component {
    render() {
        return (
            <div className={ styles['chat'] }>
                <div className={ styles['char-area'] }>
                    asdasd
                    asdasd
                    asdasd
                    asdasd

                </div>
                <SuggestionBar />
            </div>
        );
    }
}

export default Chat;
