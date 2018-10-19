import React from 'react';
import { connect } from 'react-redux';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';

import styles from './chat.scss';

class Chat extends React.Component {
    render() {
        const {
            chat: {
                messages,
            },
        } = this.props;

        return (
            <div className={ styles['chat'] }>
                <div className={ styles['char-area'] }>
                    { messages.map(message => (
                        <Messages
                            key={ message.id }
                            type={ message.type }
                            message={ message.message }
                        />
                    ))}
					<Messages type='user' message={ 'one two' }/>
					<Messages message={ 'one two' }/>
                </div>
                <SuggestionBar />
            </div>
        );
    }
}

const mapStateToProps = (state) => ({
    chat: state.chat,
});

export default connect(mapStateToProps)(Chat);
