const PROXY_CONFIG = [
  {
    context: [
      "/eventos",
    ],
    target: "https://localhost:5001",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
