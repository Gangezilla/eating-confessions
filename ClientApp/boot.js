import './css/site.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import * as RoutesModule from './routes';
let routes = RoutesModule.routes;

function renderApp() {
    console.log('bing bong');
    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
    ReactDOM.render(
        <AppContainer>
            <BrowserRouter children={ routes } basename={ baseUrl } />
        </AppContainer>,
        document.getElementById('react-app')
    );
}
console.log('hello');

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept('./routes', () => {
        routes = require('./routes').routes;
        renderApp();
    });
}
