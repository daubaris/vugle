import React from 'react';
import { Icon } from 'evergreen-ui';
import styles from './messages.scss';
import classnames from 'classnames';

class Messages extends React.Component {
	render() {
		const {
			type,
			message,
		} = this.props;

		const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);

		return (
			<div className={ wrapperClassname }>
				{ type !== 'user' &&
					<div className={ styles['avatar'] }>
						🤖	
					</div>
				}
				<div className={ styles['message-type-' + (type === 'user' ? 'blue' : 'gray')] }>
					{ message }
				</div>
			</div>
		);
	}
}

export default Messages;
