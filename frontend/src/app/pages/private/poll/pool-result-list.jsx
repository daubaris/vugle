import React from 'react';
import PollResult from './poll-result';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';

class PollResultList extends React.Component {
    constructor(props) {
        super(props);
 
    }

    render() {
        return (
            <Container>
                {
                    this.props.data.map(poll => (
                        <Row key={ poll.id }>
                            <Col lg={{ size: 12 }}>
                                <Card>
                                    <CardBody>
                                        <PollResult data={poll} />
                                    </CardBody>
                                </Card>
                            </Col>
                        </Row>
                    ))
                }
            </Container>
        );
    }
}

export default PollResultList;