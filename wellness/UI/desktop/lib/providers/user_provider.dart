import 'dart:convert';

import 'package:desktop/providers/base_provider.dart';
import 'package:http/http.dart' as http;

import '../models/user.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<dynamic> updateUser(int id, String firstName, String lastName,
      String email, String userName, String phone) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": "",
      "confrimPassword": "",
      "phone": phone
    });

    print("Ispis iz jsonRequesta: $jsonRequest");

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
