import React from 'react';
import styles from "./topbar.scss";
import { SideSheet, Position, Paragraph, Dialog } from 'evergreen-ui';
import Button from "app/components/button/button";
import NotificationList from "app/pages/public/landing/topbar/notificationList";

class Topbar extends React.Component {
    constructor(props) {
        super(props);

        this.onClick = this.onClick.bind(this);
        this.onClickNotificationModal = this.onClickNotificationModal.bind(this);

        this.state = {
            isShown: false,
            isNotificationModalShown: false,
        }
    }

    onClick() {
        this.setState({
            isShown: true
        })
    }

    onClickNotificationModal() {
        this.setState({
            isNotificationModalShown: true
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
                    width={ 320 }
                    onCloseComplete={() => this.setState({ isShown: false })}
                >
                    <Paragraph margin={ 40 }>
                        <Dialog
                            isShown={ this.state.isNotificationModalShown }
                            title="Žinutės"
                            onCloseComplete={ () => this.setState({ isNotificationModalShown: false }) }
                            hasFooter={ false }
                        >
                            <NotificationList/>
                        </Dialog>
                        <Button title="Rodyti žinutes"
                                onClick={ this.onClickNotificationModal }
                        />
                    </Paragraph>

                </SideSheet>
            </div>
        );
    }
}

export default Topbar;
