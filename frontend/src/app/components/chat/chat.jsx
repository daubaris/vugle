import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';
import chatActions from './redux/actions';

import styles from './chat.scss';

class Chat extends React.Component {
    constructor(props) {
        super(props);

    }

    componentDidMount() {
        const {
            actions,
        } = this.props;

        actions.chat.addBotMessage({ title: 'Sveiki' });
        actions.chat.addBotMessage({ title: 'Kaip galetume Jums padeti?' });
    }

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

const mapDispatchToProps = (dispatch) => ({
    actions: {
        chat: bindActionCreators(chatActions, dispatch)
    },
});

export default connect(mapStateToProps, mapDispatchToProps)(Chat);