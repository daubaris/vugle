import React from 'react';
import styles from './typing-message.scss';
import classnames from "classnames";

class TypingMessage extends React.Component {
    render() {
        const {
            type
        } = this.props;
        const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);
        return (
            <div className={ wrapperClassname }>
                <div className={ styles['avatar'] }>
                    🤖
                </div>
                <div className={ styles['lds-ellipsis'] }>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
            </div>
        );
    }
}
export default TypingMessage;
