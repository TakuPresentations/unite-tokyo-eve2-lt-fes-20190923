import React from 'react';
import './App.css';

const inputContainerStyles = {
  width: '50%',
};

class App extends React.Component {
  render():
  | React.ReactElement<any, string | React.JSXElementConstructor<any>>
  | string
  | number
  | {}
  | React.ReactNodeArray
  | React.ReactPortal
  | boolean
  | null
  | undefined {
    return (
    <div className="App">
      <header className="App-header">
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
  }
}

export default App;
