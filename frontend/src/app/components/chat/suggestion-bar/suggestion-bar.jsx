import React from 'react';
import SuggestionsBubble from '../suggestions-bubble/suggestions-bubble';
import styles from './suggestions-bar.scss';

class SuggestionBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            suggestions: [{
                id: 1,
                title: 'test'
            },{
                id: 2,
                title: 'test'
            },{
                id: 3,
                title: 'test'
            },{
                id: 4,
                title: 'test'
            }]
        };

        this.onClick = this.onClick.bind(this);
    }


    onClick(id) {
        alert(id);
    }

    render() {
		const {
            suggestions,
		} = this.state;

		return (
			<div className={ styles['suggestion-bar'] }>
				{ suggestions.map(suggestion => (
					<SuggestionsBubble
						key={ suggestion.id }
					    id={ suggestion.id }
					    title={ suggestion.title }
						onClick={ this.onClick }
					/>
				))}
			</div>
		);
	}
}

export default SuggestionBar;
