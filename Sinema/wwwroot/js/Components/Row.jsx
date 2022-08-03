class Row extends React.Component {
    constructor(props) {
        super(props);
        this.getClass = this.getClass.bind(this);
    }

    getClass(status) {
        if (status == "free") return "freeStyle";
        else {
            if (status == "busy") return "busyStyle";
            else return "selectedStyle";
        }
    }

    render() {
        var row = this.props.row;
        var rowPlaces = row => {
            let content = [];
            for (let curPlace of row.Places) {
                content.push(
                    <Place
                        key={curPlace.id}
                        placeNumber={curPlace.PlaceNum}
                        condition={curPlace.Availability == "free"}
                        class={this.getClass(curPlace.Availability)}
                        onClick={() => this.props.onClick(curPlace.id, row.Row)}
                    />
                )
            }
            return (
                <div className="row">
                    {rowPlaces}
                </div>
            )
        }
    }
}