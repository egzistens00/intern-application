from flask import Flask, request, jsonify
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

@app.route('/feedback', methods=['POST'])
def feedback():
    data = request.get_json()

    # Basic validation
    if not data or 'name' not in data or 'feedback' not in data:
        return jsonify({'error': 'Invalid input'}), 400

    name = data['name']
    feedback = data['feedback']

    # Log to terminal for now (you can extend this to store in DynamoDB or a file)
    print(f"Received feedback from {name}: {feedback}")

    return jsonify({'message': 'Feedback received'}), 200

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')

