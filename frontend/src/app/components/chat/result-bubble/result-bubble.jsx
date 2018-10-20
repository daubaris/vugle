import React from 'react';
import styles from './result-bubble.scss';

class ResultBubble extends React.Component {
	render() {
		const {
			item,
		} = this.props;

		if (!item || !item.url) {
			return null;
		}

		return (
			<div className={ styles['result-bubble'] }>
				<div className={ styles['image-wrap'] }>
				<div
					className={ styles['image'] }
					style={{
						backgroundRepeat: "no-repeat",
						background: `url(${item.photo}) no-repeat`,
						backgroundPosition: "center center",
						backgroundSize: "contain"
					}}
				/>
				</div>
				<div className={ styles['title'] }>
					<a href={item.url}>{item.title}</a>
				</div>
				<div className={ styles['description']}>{ item.description }</div>
				<div className={ styles['date'] }>{ item.date }</div>
			</div>
		);
	}
}

export default ResultBubble;
