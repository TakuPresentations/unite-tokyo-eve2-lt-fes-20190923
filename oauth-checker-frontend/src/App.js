import React from 'react';
import './App.css';
import { Input, Button } from 'react-rainbow-components'

const inputContainerStyles = {
  width: '50%',
};

class App extends React.Component {
  constructor(props){
    super(props);

    this.state = {
      url: '',
    };
    this.onUrlInput = this.onUrlInput.bind(this);
    this.onRedirect = this.onRedirect.bind(this);
  }

  onUrlInput(event) {
    console.log(event);
    this.setState({ url: event.target.value });
  }

  onRedirect(event) {
    window.location.href = this.state.url;
  }

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
                  onChange={this.onUrlInput}
                  type="text" />
              </div>
            </div>
          </div>
          <div className="rainbow-p-vertical_large rainbow-align-content_center rainbow-flex_wrap">
            <div className="rainbow-m-horizontal_medium">
              <Button
                label="Execute"
                onClick={this.onRedirect}
                variant="brand" />
            </div>
          </div>
        </header>
      </div>
    );
  }
}

export default App;
