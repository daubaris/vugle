import React from 'react';
import styles from './result-bubble.scss';

class ResultBubble extends React.Component {
	render() {
		const {
			item,
		} = this.props;

		if (!item) {
			return null;
		}

		return (
			<div className={ styles['result-bubble'] }>
				{ item.photo &&
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
				}
				{ item.title &&
					<div className={ styles['title'] }>
						<a href={item.url} target='_blank'>{item.title}</a>
					</div>
				}
				{ item.description &&
					<div className={ styles['description']}>{ item.description }</div>
				}
				{ item.date &&
					<div className={ styles['date'] }>{ item.date }</div>
				}
			</div>
		);
	}
}

export default ResultBubble;
