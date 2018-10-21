import React from 'react';
import { Spinner } from 'evergreen-ui';
import restService from 'app/services/api';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';
import PollResultList from './pool-result-list';

class PollResultsPage extends React.Component {
    constructor(props) {
        super(props);

        this.loadCharts = this.loadCharts.bind(this);

        this.state = {
            polls: []
        }
    }

    componentDidMount() {
        this.loadCharts();
    }

    loadCharts() {
        return restService.get('api/poll/all').then(response => {
            if (response) {
                this.setState(this.state.polls = response);
            }
        })
    }


    render() {
        return (
            <Container>
                {
                    <Row>
                        <Col lg={{ size: 12 }}>
                            <Card>
                                <CardBody>
                                    <h1>Apklausų rezultatai</h1>
                                    {this.state.polls.length == false && <Spinner />}
                                    {this.state.polls.length === 0 && <div>Apklausų nėra</div>}
                                    {this.state.polls.length > 0 && <PollResultList data={this.state.polls} />}
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                }
            </Container>
        );
    }
}

export default PollResultsPage;
