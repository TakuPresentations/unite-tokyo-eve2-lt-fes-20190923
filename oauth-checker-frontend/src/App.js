import React from 'react';
import './App.css';
import { Input, Button } from 'react-rainbow-components'

const inputContainerStyles = {
  width: '50%',
};

class App extends React.Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <div className="rainbow-p-around_x-large">
            <div className="rainbow-flex rainbow-p-bottom_medium">
              <div className="rainbow-p-horizontal_small" style={{width: '100%'}}>
                <Input
                  label="Input URLScheme"
                  placeholder="URL"
                  type="text" />
              </div>
            </div>
          </div>
          <div className="rainbow-p-vertical_large rainbow-align-content_center rainbow-flex_wrap">
            <div className="rainbow-m-horizontal_medium">
              <Button
                label="Execute"
                onClick={() => alert('clicked!')}
                variant="brand" />
            </div>
          </div>
        </header>
      </div>
    );
  }
}

export default App;
