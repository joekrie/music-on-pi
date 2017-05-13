import React from 'react';
import ReactDOM from 'react-dom';

import TrackList from './components/TrackList';
import Uploader from './components/Uploader';

document.addEventListener('DOMContentLoaded', () => {
    ReactDOM.render(
        <Uploader />,
        document.getElementById('app')
    );
});
