import React from 'react';
import styles from "./topbar.scss";
import { SideSheet, Position, Paragraph } from 'evergreen-ui';
class Topbar extends React.Component {
    constructor(props) {
        super(props);
        this.onClick = this.onClick.bind(this);
        this.state = {
            isShown: false
        }
    }
    onClick() {
        this.setState({
            isShown: true
        })
    }
    render() {
        return (
            <div className={ styles['topbar'] }>
                <div className={ styles['title'] }>
                    vugle
                </div>
                <div className={ styles['burger'] } onClick={ this.onClick }>
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
                <SideSheet
                    position={Position.RIGHT}
                    isShown={ this.state.isShown}
                    onCloseComplete={() => this.setState({ isShown: false })}
                >
                    <Paragraph margin={40}>Basic Example</Paragraph>
                </SideSheet>
            </div>
        );
    }
}
export default Topbar;
