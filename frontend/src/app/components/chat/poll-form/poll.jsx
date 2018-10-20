import React from 'react';

import restService from '../../../services/api';

import PollForm from './poll-message-form';

class Poll extends React.Component {
    constructor(props){
        super(props);
    }

    componentDidMount(){
        const {
            id,
        } = this.props;

        console.log(id);
        restService.get(`/api/Poll/${id}`);
    }


    render() {
        return (
            <PollForm/>
        );
    }
}

export default Poll;