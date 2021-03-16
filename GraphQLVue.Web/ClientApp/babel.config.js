module.exports = {
  presets: [
    '@vue/cli-plugin-babel/preset'
    ],
    module: {
        rules: [
            {
                test: /\.(graphql|gql)$/,
                exclude: /node_modules/,
                loader: 'graphql-tag/loader'
            }],
    }
}
