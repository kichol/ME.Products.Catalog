const PROXY_CONFIG = [
  {
    context: [
      "/api/products",
    ],
    target: "https://localhost:7088",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
