import 'package:mobile/models/treatment.dart';

class RecommendedHelper {
  static List<Treatment>? _treatments;

  static List<Treatment>? getRecommendation() {
    return _treatments;
  }

  static void saveRecommend(List<Treatment> treatments) {
    _treatments = treatments;
  }

  static void removeRecommendation() {
    _treatments = null;
  }
}
