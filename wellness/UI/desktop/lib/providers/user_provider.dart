import 'dart:convert';

import 'package:desktop/providers/base_provider.dart';
import 'package:desktop/utils/role_store.dart';
import 'package:http/http.dart' as http;

import '../models/user.dart';
import '../utils/token_store.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<dynamic> updateUser(
    int id,
    String firstName,
    String lastName,
    String email,
    String userName,
    String phone,
    bool status,
  ) async {
    var url = "$baseUrl$endpoint/$id/update";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "phone": phone,
      "status": status,
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> addUser(String firstName, String lastName, String email,
      String userName, String phone) async {
    var url = "$baseUrl$endpoint/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "phone": phone
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> addWorker(
      String firstName,
      String lastName,
      String email,
      String userName,
      String phone,
      int roleId,
      String picture,
      bool status,
      int shiftId) async {
    var url = "$baseUrl$endpoint/register";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "picture": picture,
      "roleId": roleId,
      "phone": phone,
      "status": status,
      "shiftId": shiftId
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> updateWorker(
      int id,
      String firstName,
      String lastName,
      String email,
      String userName,
      String phone,
      int roleId,
      String picture,
      bool status,
      int shiftId) async {
    var url = "$baseUrl$endpoint/$id/update";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "picture": picture,
      "roleId": roleId,
      "phone": phone,
      "status": status,
      "shiftId": shiftId
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> employeeProfilUpdate(
    int id,
    String firstName,
    String lastName,
    String email,
    String userName,
    String phone,
    String password,
    String picture,
  ) async {
    var url = "$baseUrl$endpoint/$id/update-employee";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "firstName": firstName,
      "lastName": lastName,
      "email": email,
      "userName": userName,
      "password": password,
      "phone": phone,
      "picture": picture
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<bool> login(String username, String password) async {
    var url = "${baseUrl}Auth/login";
    var uri = Uri.parse(url);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "userName": username,
      "password": password,
      "desktop": true,
    });

    var response = await http.post(uri,
        headers: {'Content-Type': 'application/json'}, body: jsonRequest);

    try {
      if (isValidResponse(response)) {
        var data = jsonDecode(response.body);
        TokenManager.saveToken(data['token']);
        RoleManager.saveIsAdmin(data['message']);
        RoleManager.setUserId(data['token']);

        return true;
      } else {
        throw Exception("Unknown error");
      }
    } catch (e) {
      return false;
    }
  }

  Future<User> getById() async {
    int id = RoleManager.getUserId();

    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> forgotPassword(
    String userName,
    String email,
  ) async {
    var url = "$baseUrl$endpoint/reset";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? '');

    var jsonRequest =
        jsonEncode(<String, dynamic>{"userName": userName, "email": email, "mobile":false});

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = response.body;
      return data;
    } else {
      throw Exception("Unknown error");
    }
  }
}
