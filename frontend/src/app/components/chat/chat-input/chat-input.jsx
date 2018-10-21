import React from 'react';
import { TextInput, Icon } from 'evergreen-ui';
import styles from './chat-input.scss';

class ChatInput extends React.Component {
	render() {
		return (
			<div className={ styles['chat-input'] }>
				<input className={ styles['input'] } type="text"/>
				<div className={ styles['button-wrapper'] }>
					<Icon size={20} className={ styles['button'] } icon="circle-arrow-right"/>
				</div>
			</div>
		);
	}
}

export default ChatInput
