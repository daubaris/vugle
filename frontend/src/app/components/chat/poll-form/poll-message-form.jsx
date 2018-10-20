import React from 'react';
import classnames from 'classnames';
import Component from "@reactions/component";
import Chart from "app/components/chart/chart";
import {Icon, RadioGroup, Spinner} from 'evergreen-ui';

import restService from 'app/services/api';
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
						isChartShown: false,
						value: props.poll.options[0].title,
						hasSubmitted: false,
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
		
		submitAnswer() {
			this.setState({
				isSubmitting: true,
			});

			const {
				value,
			} = this.state;

			const data = {
				pollId: this.props.poll.id,
				response: value,
			};

			if (value) {
				restService.post('/api/Poll/Response', data).then(() => {
					this.setState({
						hasSubmitted: true,
					});
				});
			}

		}

    render() {
        const {
					type,
					message,
					poll,
        } = this.props;

        const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);

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
                                marginTop={20}
                                size={16}
                                label="Pasirinkimai"
                                value={state.value}
                                options={state.options}
                                onChange={value => this.setState({value})}
                                defaultValue={null}
                            />
                        )}
                    </Component>
                    <div className={chatStyles['show-results']}>
												{	!this.state.hasSubmitted &&
													<div>
														<Button size="sm" title="Siųsti atsakymą" onClick={() => this.submitAnswer()}/>
													</div>
												}
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
