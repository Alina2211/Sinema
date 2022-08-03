function Place(props) {
    return (
        <button
            className={props.class}
            disabled={props.condition}
            onClick={props.onClick}
        >
            {props.placeNumber}
        </button>
    );
}