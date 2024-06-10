import 'dart:convert';

import 'package:mobile/models/treatment.dart';
import 'package:mobile/providers/base_provider.dart';
import 'package:mobile/utils/user_store.dart';

class TreatmentProvider extends BaseProvider<Treatment> {
  TreatmentProvider() : super("Treatment");

  @override
  Treatment fromJson(data) {
    return Treatment.fromJson(data);
  }

  Future<List<Treatment>> recommendation() async {
    int id = int.parse(UserManager.getUserId()!);

    var url = "${baseUrl}Recommendation/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http!.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      return data.map((x) => fromJson(x)).cast<Treatment>().toList();
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<void> initialize() async {
    var url = "${baseUrl}Recommendation/";
    var uri = Uri.parse(url);

    var response = await http!.get(uri);

    if (isValidResponse(response)) {
      return;
    } else {
      throw Exception("Unknown error");
    }
  }
}
