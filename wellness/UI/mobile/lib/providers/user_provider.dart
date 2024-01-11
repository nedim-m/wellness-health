import 'dart:convert';

import 'package:mobile/models/user.dart';
import 'package:mobile/providers/base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<dynamic> register(
      String firstName,
      String lastName,
      String email,
      String userName,
      String password,
      String confrimPassword,
      String phone) async {
    var url = "${baseUrl}Auth/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? ''); //zbog testa

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "confrimPassword": confrimPassword,
      "phone": phone
    });

    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
