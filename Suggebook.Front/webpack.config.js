var webpack = require("webpack");
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
  entry: "./src/home.js",
  output: {
    path: "suggebook.front/content",
    filename: "bundle.js",
    publicPath: "/content/"
  },
  module: {
    loaders: [
      {
        test: /\.js$/,
        exclude: /(node_modules)/,
        loader: "babel-loader",
        query: {
          presets: ["latest", "stage-2", "react"]
        }
      },
      {
        test: /\.scss$/,
        use: [
          {
            loader: "sass-loader",
            options: {
              includePaths: ["~/src/styles"]
            }
          }
        ]
      },
      {
        test: /\.(jpg|png)$/,
        loader: "url-loader"
      }
    ]
  },
  plugins: [new ExtractTextPlugin("bundle.css")]
};
