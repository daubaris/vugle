import React from 'react';
import classnames from 'classnames';
import Component from "@reactions/component";
import Chart from "app/components/chart/chart";
import {Icon, RadioGroup} from 'evergreen-ui';

import { Button } from 'app/components/button';
import styles from './poll-form.scss';
import chatStyles from '../messages/messages.scss';


function mapOptions(options) {
    return options.map((option) => ({
        label: option.title,
        value: option.title,
    }));
}

class PollForm extends React.Component {
    constructor(props) {
        super(props);

        this.showChart = this.showChart.bind(this);

        this.state = {
            isChartShown: false
        }
    }
    showChart() {
        if (this.state.isChartShown === false) {
            this.setState({
                isChartShown: true
            })
        } else {
            this.setState({
                isChartShown: false
            })
        }
    }

    render() {
        const {
					type,
					message,
					poll,
        } = this.props;

        const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);

        const chartData = [
            {
                value: 111,
                color: "#F7464A",
                highlight: "#FF5A5E",
                label: "Red"
            },
            {
                value: 123,
                color: "#46BFBD",
                highlight: "#5AD3D1",
                label: "Green"
            },
            {
                value: 777,
                color: "#FDB45C",
                highlight: "#FFC870",
                label: "Yellow"
            },
            {
                value: 999,
                color: "red",
                highlight: "#FFC870",
                label: "Yellow"
            }
        ];

        return (
            <div className={wrapperClassname}>
                <div className={chatStyles['message-type-gray']}>
                    <div className={styles['text-primary']}><b>{poll.title}</b></div>
                    <div>{poll.description}</div>
                    <Component
                        initialState={{
                            options: mapOptions(poll.options),
                            value: null,
                        }}
                    >
                        {({state, setState}) => (
                            <RadioGroup
                                marginTop={40}
                                size={16}
                                label="Pasirinkimai"
                                value={state.value}
                                options={state.options}
                                onChange={value => setState({value})}
                                defaultValue={null}
                            />
                        )}
                    </Component>
                    <div className={chatStyles['show-results']}>
                        <div>
                            <Button size="sm" title="Rodyti rezultatus" onClick={() => this.showChart()}/>
                        </div>
                        <div>
                            {this.state.isChartShown && <Chart data={ poll.options }/>}
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}


export default PollForm;
