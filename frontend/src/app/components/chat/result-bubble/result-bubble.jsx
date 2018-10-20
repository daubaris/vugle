import React from 'react';
import styles from './result-bubble.scss';

class ResultBubble extends React.Component {
	render() {
		const {
			items
		} = this.props;

		return (
				<div className={ styles['result-bubble'] }>
					<div className={ styles['image-wrap'] }>
					<div
						className={ styles['image'] }
						style={{
							backgroundRepeat: "no-repeat",
							background: "url(https://upload.wikimedia.org/wikipedia/commons/thumb/7/77/Google_Images_2015_logo.svg/1200px-Google_Images_2015_logo.svg.png) no-repeat",
							backgroundPosition: "center center",
							backgroundSize: "contain"
						}}
					/>
					</div>
					<div className={ styles['title'] }>
						<a href="">test</a>
					</div>
					<div className={ styles['description']}>test description</div>
					<div className={ styles['date'] }>test date</div>
				</div>
		);
	}
}

export default ResultBubble;
