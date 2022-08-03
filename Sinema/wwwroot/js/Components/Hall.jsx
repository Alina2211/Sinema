class Hall extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            rows: props.rows,
            orders: []
        };
    }

    handleClick(id, rowNum) {
        let place = findPlace(id, rowNum);
        if (place.Availability == "free") {
            place.Availability = "selected";
            this.setState()
        }
        else
            if (place.Availability == "selected"{

            }
    }

    findPlace(id, rowNum) {

    }

    render() {
        var hall = this.state.rows;

    }
}