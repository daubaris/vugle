import React from 'react';

import restService from '../../../services/api';

import PollForm from './poll-message-form';

class Poll extends React.Component {
    constructor(props){
        super(props);

        this.state= {
            poll: [],
            isLoading: true,
        };
    }

    componentDidMount(){
        const {
            id,
        } = this.props;

        restService.get(`/api/Poll/${id}`).then((poll) => {
            this.setState({
                poll,
                isLoading: false,
            });
        });
        
    }


    render() {
        const {
            poll,
            isLoading,
        } = this.state;

        return (
            !isLoading &&
                <PollForm 
                    poll={poll}
                />
        );
    }
}

export default Poll;