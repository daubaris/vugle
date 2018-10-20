import React from 'react';
import styles from './messages.scss';
import Poll from './../poll-form/poll';
import ResultBubble from "app/components/chat/result-bubble/result-bubble";
import classnames from 'classnames';

class Messages extends React.Component {
	render() {
		const {
			type,
			message,
			allMessage: {
                pollId,
				data,
			},
		} = this.props;

		const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);

		return (
			<div className={ wrapperClassname }>
				{ type !== 'user' &&
					<div className={ styles['avatar'] }>
						🤖
					</div>
				}
				{ pollId &&
					<Poll id={ pollId } />
				}
				{ !pollId && !data &&
					<div className={ styles['message-type-' + (type === 'user' ? 'blue' : 'gray')] }>
						{ message }
					</div>
				}
				{ data &&
					<ResultBubble item={ data }/>
				}
			</div>
		);
	}
}

export default Messages;
