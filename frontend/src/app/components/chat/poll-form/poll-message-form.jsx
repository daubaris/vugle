import React from 'react';
import classnames from 'classnames';
import Component from "@reactions/component";

import { Icon, RadioGroup } from 'evergreen-ui';

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
	render() {
		const {
			type,
			message,
		} = this.props;

		const poll = {
			"id": 0,
			"title": "AXUJENAAAS POLLAS",
			"description": "pollas apie hakatono maista.... Lorem ea sit officia id. Velit non labore Lorem excepteur. Deserunt minim occaecat ex aliquip mollit aliqua. Ut consectetur ipsum irure non duis esse reprehenderit ullamco mollit. Reprehenderit labore aliquip id nulla nostrud est magna exercitation sit id.",
			"date": "2018-10-20T12:00:27.589Z",
			"options": [
			  {
				"title": "01",
				"value": "01"
			  },
			  {
				"title": "02",
				"value": "02"
			  },
			  {
				"title": "03",
				"value": "03"
			  },
			  {
				"title": "04",
				"value": "04"
			  }
			]
		}

		const wrapperClassname = classnames(styles['wrapper'], type === 'user' ? styles['blue'] : styles['gray']);

		return (
			<div className={ wrapperClassname }>
				<div className={ chatStyles['message-type-gray'] }>
					<div className={ styles['text-primary']} ><b>{poll.title}</b></div>
					<div>{poll.description}</div>
					<Component
						initialState={{
							options: mapOptions(poll.options),
							value: null,
						}}
						>
						{({ state, setState }) => (
							<RadioGroup
								marginTop={20}
								size={16}
								label="Pasirinkimai"
								value={state.value}
								options={state.options}
								onChange={value => setState({ value })}
								defaultValue={null}
							/>
						)}
					</Component>

					<Button
						title="Atsakyti!"
					/>
				</div>
			</div>
		);
	}
}



export default PollForm;
